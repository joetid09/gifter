import React, { UseEffect, UseState } from 'react';

const PostList = () => {
    const [posts, setPosts] = UseState([]);

    useEffect(() => {
        fetch('/api/posts') //this is just an HTTP request to the api
            .then(res => res.json) //request the json data found on api/posts
            .then(data => setPosts(data)); //takes the json data received, and sets the posts state
    }, [])

    //Once the useEffect is complete, use the info to display

    return (
        <div>
            {posts.map((post) => (
                <div key={post.id}>
                    <img>{post.imageUrl}</img>
                    <p>
                        <strong>{post.title}</strong>
                    </p>
                    <p>{post.caption}</p>
                </div>
            )
            )}
        </div>
    );

};

export default PostList;
//setting as default takes away needing to import with curly braces{}

