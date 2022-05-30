FROM node:alpine
EXPOSE 4200
#WORKDIR /app

WORKDIR /dist/src/app
COPY AngularClient/package*.json ./
COPY AngularClient/. .
RUN npm install
RUN npm install -g @angular/cli
CMD ["ng", "serve", "--port", "4200",  "--host=0.0.0.0"]


