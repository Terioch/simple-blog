<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <link
    rel="stylesheet"
    href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css"
  />
  <title>New Post</title>
</head>
<body>
  <?php include("../shared/adminNavigation.php") ?>

  <div class="container">
    <form id="newPostForm">
      <div class="form-group mb-3">
        <label for="titleInput">Title</label>
        <input type="text" class="form-control" id="titleInput" placeholder="Enter title">
      </div>
      <div class="form-group mb-3">
        <label for="excerptInput">Excerpt</label>
        <textarea class="form-control" id="excerptInput" rows="3"></textarea>
      </div>
      <div class="form-group mb-3">
        <label for="imageInput">Image</label>
        <input type="file" class="form-control-file" id="imageInput">
      </div>
      <div class="form-group mb-3">
        <label for="contentInput">Post Content</label>
        <textarea class="form-control" id="contentInput" rows="6"></textarea>
      </div>
      <button type="submit" class="btn btn-primary">Create</button>
    </form>
  </div>

  <script type="module" src="../components/admin/newPost.js"></script>
</body>
</html>