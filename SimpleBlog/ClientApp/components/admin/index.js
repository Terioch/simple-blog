class AdminHome {
  constructor() {
    this.onInit();
  }

  onInit() {
    if (!this.isAuthenticated()) {
      window.location.href = "/home.php";
      console.log("Not authenticated");
    }

    this.getPosts();
  }

  isAuthenticated() {
    const accessToken = JSON.parse(localStorage.getItem("access-token"));
    console.log(accessToken);
    if (!accessToken) return false;
    const expires = JSON.parse(localStorage.getItem("expires"));
    console.log(expires);
    return new Date() < new Date(expires);
  }

  async getPosts() {
    const accessToken = JSON.parse(localStorage.getItem("access-token"));

    const response = await fetch("https://localhost:7256/api/postAdmin", {
      method: "GET",
      headers: {
        Authorization: `Bearer ${accessToken}`,
      },
    });

    const posts = await response.json();
    console.log(posts);
  }
}

new AdminHome();
