export default interface Book {
    bookId: number;
    title: string;
    author: string;
    pictureUrl: string;
    synopsis: string;
    amazonLink: string;
    bookReviews?: any;
    price: number;
    bookGenre: number;
}