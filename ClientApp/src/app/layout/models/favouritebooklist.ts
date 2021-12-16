export interface BookListItem {
    bookId: number;
    title: string;
    author: string;
    link: string;
    price: number;
    pictureUrl: string;
    quantity: number;
}

export interface FavouriteBookList {
    id: number;
    userId: string;
    items: BookListItem[];
}
