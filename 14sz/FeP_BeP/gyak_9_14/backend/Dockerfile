FROM node:18-alpine
WORKDIR /project/backend
COPY . .
RUN yarn install --production
CMD [ "node","sajatmodul.js" ]
EXPOSE 3300