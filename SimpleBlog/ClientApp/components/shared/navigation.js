class Navigation {
  constructor() {
    this.onInit();
  }

  onInit() {
    document
      .getElementById("postSearchForm")
      .addEventListener("submit", this.searchPosts.bind(this));
  }

  async searchPosts(e) {
    e.preventDefault();
    window.location.href = `/postSearch.php?search=${e.target["searchInput"].value}`;
  }
}

new Navigation();
