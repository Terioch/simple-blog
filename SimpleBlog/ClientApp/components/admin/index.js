class AdminHome {
  constructor() {
    this.onInit();
  }

  onInit() {
    if (!this.isAuthenticated()) {
      //window.location.href = "/";
      console.log("Not authenticated");
    }
  }

  isAuthenticated() {
    const accessToken = localStorage.getItem("access-token");
    console.log(accessToken);
    if (!accessToken) return false;
    const expires = localStorage.getItem("expires");
    console.log(expires);
    return new Date(expires) < new Date();
  }
}

new AdminHome();
