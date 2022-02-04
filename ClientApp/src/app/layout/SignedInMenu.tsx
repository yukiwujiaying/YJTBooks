import { Button, Menu, Fade, MenuItem } from "@mui/material";
import React from "react";
import { Link } from "react-router-dom";
import { signOut } from "../../components/account/accountSlice";
import { ClearState } from "../../components/catalog/bookSlice";
import { clearFavouriteBookList } from "../../components/FavouriteBookList/FavouriteBookListSlice";
import { useAppDispatch, useAppSelector } from "../store/configureStore";

export default function SignedInMenu() {
    const dispatch = useAppDispatch();
    const {user} = useAppSelector(state => state.account);
    const [anchorEl, setAnchorEl] = React.useState(null);
  const open = Boolean(anchorEl);
  const handleClick = (event: any) => {
    setAnchorEl(event.currentTarget);
  };
  const handleClose = () => {
    setAnchorEl(null);
  };

  return (
    <>
      <Button
        color='inherit'
        sx={{typography:'h6'}}
        onClick={handleClick}
      >
        {user?.email}
      </Button>
      <Menu
        anchorEl={anchorEl}
        open={open}
        onClose={handleClose}
        TransitionComponent={Fade}
      >
        <MenuItem component={Link} to='/profile' onClick={()=>{dispatch(ClearState())}}>Profile</MenuItem>
        <MenuItem component={Link} to='/favouriteBookList' onClick={()=>{dispatch(ClearState())}}>My Favourite</MenuItem>
        <MenuItem onClick={()=>{
                             dispatch(signOut());
                             dispatch(clearFavouriteBookList());
                             dispatch(ClearState());
                           }}>
            Logout
        </MenuItem>
      </Menu>
    </>
  );
}
