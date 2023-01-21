class PostSearch {
  constructor() {
    this.onInit();
  }

  async onInit() {
    const searchTerm = window.location.href.split("?")[1].split("=")[1];
    const posts = await this.getPostsBySearchTerm(searchTerm);
    console.log({ posts });
    this.setPostContent(posts);
  }

  async getPostsBySearchTerm(searchTerm) {
    const response = await fetch(
      `https://localhost:7256/api/post?searchTerm=${searchTerm}`
    );
    const filteredPosts = await response.json();
    return filteredPosts;
  }

  setPostContent(posts) {
    document.getElementById(
      "searchResults"
    ).innerHTML = `${posts.length} results`;

    for (const post of posts) {
      const container = document.getElementById("postsContainer");
      const html = `<div>
        <h2>${post.title}</h2>
        <p>${post.excerpt}</p>
      </div>`;

      container.insertAdjacentHTML("beforeend", html);
    }
  }
}

new PostSearch();
