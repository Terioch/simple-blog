<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Navigation</title>
  </head>
  <body>
    <nav class="navbar navbar-expand-lg bg-light">
        <div class="container-fluid">
            <a class="navbar-brand" href="/index.php">Simple Blog</a>            
            <div class="d-flex align-items-center">
                <form id="postSearchForm" class="me-3">
                    <div class="input-group">
                        <span class="input-group-text">
                            <span class="material-icons">search</span>
                        </span>
                        <input id="searchInput" type="text" class="form-control" placeholder="Search" aria-label="Search">
                    </div>                      
                </form>                              
                <button class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#loginModal">Login</button>
            </div>
        </div>
    </nav>    

    <script src="../components/shared/navigation.js"></script>
  </body>
</html>
