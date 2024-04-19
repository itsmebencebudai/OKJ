async function getData(url = "") {
    const response = await fetch(url, {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
            "Authorization": "Bearer <token>"
        },
    })
    return response.json();
};

async function postData(url = "", data = {}) {
    const response = await fetch(url, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
    })
    return response;
};

async function deleteData(url = "", data = {}) {
    const response = await fetch(url, {
        method: "DELETE",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
    })
    return response;
};