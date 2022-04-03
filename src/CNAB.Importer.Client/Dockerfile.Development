FROM node:16.14-alpine
ENV PATH /app/node_modules/.bin:$PATH
WORKDIR /app

COPY src/CNAB.Importer.Client/package.json ./
COPY src/CNAB.Importer.Client/yarn.lock ./

RUN yarn install --silent

COPY src/CNAB.Importer.Client/ ./

EXPOSE 3000

CMD ["yarn", "start"]