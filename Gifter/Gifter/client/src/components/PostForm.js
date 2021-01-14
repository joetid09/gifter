import React, { useContext, useEffect, useState } from "react";
import { currentDate } from "./Date.js"
console.log(currentDate())
const PostForm = () => {
    const [inputs, setInputs] = useState({
        Title: "",
        ImageUrl: "",
        Caption: "",
        UserProfileId: 1,
        DateCreated: currentDate()
    });

    // useEffect(() => {
    //     fetch('api/')
    // })

    const handleChange = (event) => {
        setInputs((inputs) => ({ ...inputs, [event.target.name]: event.target.value }));
    }

    // const handleSubmit = (event) => {

    //     alert(`Here we go!
    //            Title is ${inputs.Title} `)
    // }

    const handleSubmit = (event) => {
        event.preventDefault();
        console.log(inputs)
        fetch('/api/post', {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                "Title": inputs.Title,
                "ImageUrl": inputs.ImageUrl,
                "Caption": inputs.Caption
            })
        }
        )
    }


    return (
        <form>
            <label>Title</label>
            <input type='text' name="Title" value={inputs.Title} onChange={handleChange} />
            <label>Image Url</label>
            <input type='text' name="ImageUrl" value={inputs.ImageUrl} onChange={handleChange} />
            <label>Caption</label>
            <input type='text' name="Caption" value={inputs.Caption} onChange={handleChange} />
            <button type="submit" onClick={handleSubmit} >submit</button>

        </form>
    )
}

export default PostForm;