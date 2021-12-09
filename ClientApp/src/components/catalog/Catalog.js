"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
function Catalog(_a) {
    var books = _a.books;
    return (React.createElement(React.Fragment, null,
        React.createElement("ul", null, books.map(function (item, index) { return (React.createElement("li", { key: index },
            item.bookId,
            " - ",
            item.title,
            " - ",
            item.author,
            " - ",
            item.price,
            " - ",
            item.amazonLink,
            " - ",
            item.synopsis,
            " - ",
            item.pictureUrl)); }))));
}
exports.default = Catalog;
//# sourceMappingURL=Catalog.js.map