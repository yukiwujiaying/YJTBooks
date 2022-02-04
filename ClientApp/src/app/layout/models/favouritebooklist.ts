export interface BookListItem {
    bookId: number;
    title: string;
    author: string;
    link: string;
    price: number;
    pictureUrl: string;
    quantity: number;
    genre: string;
    isFavourite: boolean;
}

export interface FavouriteBookList {
    id: number;
    userId: string;
    items: BookListItem[];
}
