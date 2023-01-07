class Navigation {
  constructor() {
    this.onInit();
  }

  onInit() {
    console.log("OnInit");
    document
      .getElementById("postSearchForm")
      .addEventListener("submit", this.searchPosts.bind(this));
  }

  async searchPosts(e) {
    e.preventDefault();
    console.log(e.target, e.target["searchInput"].value);
    const response = await fetch(
      `https://localhost:7256/post?searchTerm=${e.target["searchInput"].value}`
    );
    const filteredPosts = await response.json();
    console.log(filteredPosts);
  }
}

new Navigation();
