from Flask import Flask, render_template, request, redirect, url_for
import requests

app = Flask(__name__)

# Replace these values with your actual TikTok API credentials
CLIENT_ID = '7306455748123838469'
CLIENT_SECRET = 'jv8NgXdLDqerDOBbgL4lY3GhycQaRRoO'
REDIRECT_URI = 'http://localhost:5000/callback'  # Set this in your TikTok Developer Console

# TikTok API endpoints
AUTH_URL = 'https://open-api.tiktok.com/platform/oauth/connect/'
UPLOAD_URL = 'https://open-api.tiktok.com/video/upload/'

# Store the access token in memory (for simplicity in this example)
access_token = 'awohjs0eriawouvt'

# Render the index page
@app.route('/')
def index():
    return render_template('index.html')

# Redirect to TikTok for user authentication
@app.route('/authenticate')
def authenticate():
    return redirect(f"{AUTH_URL}?client_key={CLIENT_ID}&redirect_uri={REDIRECT_URI}&response_type=code")

# Callback route after user authentication
@app.route('/callback')
def callback():
    global access_token

    # Retrieve the authorization code from the query parameters
    code = request.args.get('code')

    # Exchange the authorization code for an access token
    response = requests.post('https://open-api.tiktok.com/oauth/access_token',
                             data={'client_key': CLIENT_ID, 'client_secret': CLIENT_SECRET,
                                   'code': code, 'grant_type': 'authorization_code'})
    data = response.json()

    if 'access_token' in data:
        access_token = data['access_token']
        return redirect(url_for('index'))
    else:
        return "Error authenticating with TikTok"

# Handle video upload
@app.route('/upload', methods=['POST'])
def upload():
    global access_token

    if not access_token:
        return redirect(url_for('authenticate'))

    # Get the uploaded video file
    video_file = request.files['video']

    # Prepare headers
    headers = {
        'Authorization': f'Bearer {access_token}',
    }

    # Make the API call to upload the video
    response = requests.post(UPLOAD_URL, headers=headers, files={'video': video_file})

    # Check the response
    if response.status_code == 200:
        return "Video uploaded successfully!"
    else:
        return f"Error uploading video. Status code: {response.status_code}\n{response.text}"

if __name__ == '__main__':
    app.run(debug=True)
