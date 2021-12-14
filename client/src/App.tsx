import React, { useEffect, useState } from "react";
import BrowseBooks from "./Features/BrowseBooks/BrowseBooks";
import { Book } from "./Features/book";
import { Container, CssBaseline } from "@mui/material";
import Header from "./Header";
import { Route } from "react-router-dom";
import HomePage from "./Features/Home/HomePage";
import BookInfo from "./Features/BookInfo/BookInfo";
import ContactPage from "./Features/Contact/ContactPage";
import ProfilePage from "./Features/Profile/ProfilePage";
import AboutPage from "./Features/About/AboutPage";

export const App: React.FC = () => {
  const [books, setBooks] = useState<Book[]>([]);

  useEffect(() => {
    fetch('http://localhost:5000/yjkbooks/books')
      .then(response => response.json())
      .then(data => setBooks(data))
  }, [])

  return (
    <>
      <CssBaseline />
      <Header />
      <Container>
        <Route exact path='/' component={HomePage} />
        <Route exact path='/browsebooks' component={BrowseBooks}>
          <BrowseBooks />
        </Route>
        <Route path='/browsebooks/:id' component={BookInfo} />
        <Route path='/contact' component={ContactPage} />
        <Route path='/profilepage' component={ProfilePage} />
        <Route path='/about' component={AboutPage} />
      </Container>
    </>
  );
}

export default App;
