import React from "react";
import { Navigate, useLocation } from "react-router-dom";
import { useAppSelector } from "../store/configureStore";



// A wrapper for <Route> that redirects to the login
// screen if you're not yet authenticated.
export default function PrivateRoute({children}:any) {
    const {user} = useAppSelector(state=>state.account);
    const location = useLocation();
    
    return (
        user
      ? children
      : <Navigate to="/login" replace state= {{ path: location.pathname }} />
    );
  }
 