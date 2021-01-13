import React, { useEffect, useState } from 'react';
import Post from "./Post";

const PostList = () => {
    const [posts, setPosts] = useState([]);

    useEffect(() => {
        fetch('/api/post')
            .then(res => res.json())
            .then(data => setPosts(data));
    }, []);

    return (
        <div>
            {posts.map((post) => (
                <Post key={post.id} post={post} />
            ))}
        </div>
    );
};

export default PostList;