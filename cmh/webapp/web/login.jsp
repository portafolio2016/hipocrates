<div class="row">
    <div class="col-md-6 col-md-offset-3">
        <form action="Login.do" method="POST">
            <div class="form-group">
                <label for="loginmail">Email</label>
                <input type="email" class="form-control" name="loginMail" id="loginMail" placeholder="Email">
            </div>
            <div class="form-group">
                <label for="loginpass">Password</label>
                <input type="password" class="form-control" name="loginPass" id="loginPass" placeholder="Password">
            </div>
            <button type="submit" class="btn btn-default">Login</button>
        </form>
        <a href="master.jsp?page=registro">Registrarse</a>
    </div>
</div>