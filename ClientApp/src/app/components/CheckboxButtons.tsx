import { FormGroup, FormControlLabel, Checkbox } from "@mui/material";
import React from "react";
import { useState } from "react";

interface Props{
    items: string[];
    checked?: string[];

    //we want to return from this list
    onChange:(items: string[])=> void;

}
export default function CheckboxButtons({items, checked, onChange}: Props) {
    const [ checkedItems, setCheckedItems] = useState(checked || [])

    function handleChecked(value:string){
        const currentIndex = checkedItems.findIndex(item => item === value);
        let newChecked: string[]=[];
        //index will be -1 if findIndex cannot find any item= value
        //if is a new check item than add it to newChecked
        if (currentIndex === -1) newChecked =[...checkedItems,value];

        //if already checked it we need to unchecked it
        //it will filter out the item ==value, only left with those item!== value
        else newChecked = checkedItems.filter(item => item !== value);
        setCheckedItems(newChecked);
        onChange(newChecked);
    }
    return (
        <FormGroup>
            {items.map(item => (
                <FormControlLabel 
                    control={<Checkbox 
                                checked={checkedItems.indexOf(item)!== -1} 
                                onClick={()=> handleChecked(item)}
                            />} 
                    label={item} 
                    key={item} 
                />
            ))}
        </FormGroup>
    )
}