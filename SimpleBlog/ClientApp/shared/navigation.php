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

    <div class="modal fade" id="loginModal" tabindex="-1" aria-labelledby="loginModalLabel" aria-hidden="true">
      <div class="modal-dialog">
          <div class="modal-content">
            <form id="loginForm">
                <div class="modal-header">
                <h5 class="modal-title" id="loginModalLabel">Login</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">              
                    <div class="input-group mb-3">
                        <span class="input-group-text" id="basic-addon1">@</span>
                        <input id="loginEmailInput" type="text" class="form-control" placeholder="Email" aria-label="Email">
                    </div>
                    <div class="input-group mb-3">
                        <span class="input-group-text" id="basic-addon1">@</span>
                        <input id="loginPasswordInput" type="password" class="form-control" placeholder="Password" aria-label="Password">
                    </div>
                    <a href="" class="link" data-bs-toggle="modal" data-bs-target="#registerModal">Register a new account here</a>
                </div>
                <div class="modal-footer">
                    <button type="submit" class="btn btn-primary">Login</button>
                </div>
            </form>    
          </div>
      </div>
    </div>

    <div class="modal fade" id="registerModal" tabindex="-1" aria-labelledby="registerModalLabel" aria-hidden="true">
      <div class="modal-dialog">
          <div class="modal-content">
            <form id="registerForm">
                <div class="modal-header">
                <h5 class="modal-title" id="registerModalLabel">Register</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                <div class="input-group mb-3">
                    <span class="input-group-text" id="basic-addon1">@</span>
                    <input id="registerUserNameInput" type="text" class="form-control" placeholder="Username" aria-label="UserName">
                </div>
                <div class="input-group mb-3">
                    <span class="input-group-text" id="basic-addon1">@</span>
                    <input id="registerEmailInput" type="text" class="form-control" placeholder="Email" aria-label="Email">
                </div>
                <div class="input-group mb-3">
                    <span class="input-group-text" id="basic-addon1">@</span>
                    <input id="registerPasswordInput" type="password" class="form-control" placeholder="Password" aria-label="Password">
                </div>
                <a href="" class="link" data-bs-toggle="modal" data-bs-target="#loginModal">Login with an existing account here</a>
                </div>
                <div class="modal-footer">
                <button type="submit" class="btn btn-primary">Register</button>
                </div>
            </form>          
          </div>
        </div>
      </div>

    <script src="../components/shared/navigation.js"></script>
  </body>
</html>
