import AppBar from "@mui/material/AppBar";
import Toolbar from "@mui/material/Toolbar";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import { NavLink } from "react-router-dom";

const pages = ["Search Books", "All Books", "About"];
const options = ["Log In", "Register"];

const midLinks = [
  { title: "books", path: "/browsebooks" },
  { title: "contact", path: "/contact" },
  { title: "about", path: "/about" },
];

const navStyles = { 
    color: "inherit", 
    textDecoration: "none",
    typography: "h6",
    '&:hover': {
        color: 'lightslategray'
    },
    '&.active': {
        color: 'black'
    }
}

const rightLinks = [
  { title: "login", path: "/login" },
  { title: "register", path: "/register" },
];

export default function Header() {
  return (
    <AppBar position="static" sx={{ mb: 4 }}>
      <Container sx={{ width: "100% " }}>
        <Toolbar sx={{display: 'flex', justifyContent: 'space-between', alignItems: 'center'}}>
          <Typography
            variant="h3"
            noWrap
            exact
            component={NavLink}
            to="/"
            sx={{ color: "inherit", textDecoration: "none", mr: 2 }}
          >
            YJT Books
          </Typography>

          <List sx={{ display: "flex" }}>
            {midLinks.map(({ title, path }) => (
              <ListItem
                component={NavLink}
                to={path}
                key={path}
                sx={navStyles}
              >
                {title.toUpperCase()}
              </ListItem>
            ))}
          </List>

          <List sx={{ display: "flex" }}>
            {rightLinks.map(({ title, path }) => (
              <ListItem
                component={NavLink}
                to={path}
                key={path}
                sx={navStyles}
              >
                {title.toUpperCase()}
              </ListItem>
            ))}
          </List>

        </Toolbar>
      </Container>
    </AppBar>
  );
}
