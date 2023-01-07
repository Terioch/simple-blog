class Home {
  constructor() {
    this.onInit();
  }

  async onInit() {
    document
      .getElementById("searchInput")
      .addEventListener("change", this.searchPosts.bind(this));

    const posts = await this.getPosts();
    this.setPostContent(posts);
  }

  async getPosts() {
    const response = await fetch("https://localhost:7256/post");
    const posts = await response.json();
    console.log(posts);
    return posts;
  }

  setPostContent(posts) {
    const container = document.getElementById("postsContainer");

    for (const post of posts) {
      const html = `<a href="/post.php?id=${post.id}" class="col col-md-3 border p-3">
        <h2>${post.title}</h2>
        <p>${post.excerpt}</p>
      </a>`;

      container.insertAdjacentHTML("beforeend", html);
    }
  }

  searchPosts(event) {
    console.log(event.target.value);
  }
}

new Home();
