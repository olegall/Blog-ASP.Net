(function (document, window, undefined) {
    document.body.addEventListener("click", (e) => {
        if (e.target && e.target.matches("[data-action='like']")) {
            e.preventDefault();

            let postId = e.target.dataset.postId;

            fetch(`/api/like/${postId}`, { method: "POST" })
                .then(response => {
                    if (response.status !== 200) {
                        throw new Error(response.statusText);
                    }

                    return response.json();
                })
                .then(likeViewModel => e.target.innerText = likeViewModel.Count);
        }
    });
})(document, window);