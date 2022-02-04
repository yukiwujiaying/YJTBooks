import React from 'react';
import PrettyRating, { IconsInterface } from "pretty-rating-react";

import {
  faStar,
  faStarHalfAlt,
} from "@fortawesome/free-solid-svg-icons";
import {
  faStar as farStar,
} from "@fortawesome/free-regular-svg-icons";

interface CustomIconsInterface {
  star: IconsInterface;
}

interface Props{
  rating:number;
}


export default function StableRating({rating}:Props){
    const icons: CustomIconsInterface = {
    star: {
        complete: faStar,
        half: faStarHalfAlt,
        empty: farStar,
    },

    };

    const colors = {
    star: ['#d9ad26', '#d9ad26', '#434b4d'],
    };

    return(
           
            <div>
              <PrettyRating value={rating} icons={icons.star} colors={colors.star} max={5}/>
            </div>
     )
}


