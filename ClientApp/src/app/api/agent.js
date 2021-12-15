"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var axios_1 = require("axios");
axios_1.default.defaults.baseURL = 'http://localhost:5000/api/';
var responseBody = function (response) { return response.data; };
var requests = {
    get: function (url) { return axios_1.default.get(url).then(responseBody); },
    post: function (url, body) { return axios_1.default.post(url, body).then(responseBody); },
    put: function (url, body) { return axios_1.default.put(url, body).then(responseBody); },
    delete: function (url) { return axios_1.default.delete(url).then(responseBody); },
};
var Catalog = {
    list: function () { return requests.get('books'); },
    details: function (bookId) { return requests.get("books/" + bookId); }
};
var agent = {
    Catalog: Catalog
};
exports.default = agent;
//# sourceMappingURL=agent.js.map