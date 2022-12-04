class Post {
  constructor() {
    this.onInit();
  }

  async onInit() {
    const post = await this.getPost();
    console.log(post);
    console.log(window.location.href);
  }

  async getPost() {
    const response = await fetch("https://localhost:7256/post");
    console.log(response);
    const post = await response.json();
    return post;
  }
}

new Post();
