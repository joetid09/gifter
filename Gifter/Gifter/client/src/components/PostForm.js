import React, { useContext, useEffect, useState } from "react";

const PostForm = () => {
    const [post, setPost] = useState();

    // useEffect(() => {
    //     fetch('api/')
    // })

    const postData = () => {
        fetch("api/post")
    }

    return (
        <div>
            <button onClick={() => postData()}>click me</button>
        </div>
    )
}

export default PostForm;