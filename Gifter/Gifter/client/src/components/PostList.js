import React, { useEffect, useState } from 'react';
import Post from "./Post";

const PostList = () => {
    const [posts, setPosts] = useState([]);
    const [viewing, setViewing] = useState(false);

    useEffect(() => {
        fetch('/api/post')
            .then(res => res.json())
            .then(data => setPosts(data));
    }, []);

    if (viewing == false) {
        return (
            <div>
                <button onClick={() => setViewing(true)}>view posts</button>
            </div>
        );
    }
    else if (viewing) {
        return (
            <div>
                <button onClick={() => setViewing(false)}>hide posts</button>
                {posts.map((post) => (
                    <Post key={post.id} post={post} />
                ))}
            </div>
        )
    }
};

export default PostList;