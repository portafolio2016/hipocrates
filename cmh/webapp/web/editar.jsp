<jsp:include page="/Actualizar.do" />
<div class="row">
    <div class="col-md-6 col-md-offset-3">
        <h1>Editar perfil</h1>
    </div>
</div>
<div class="row">
    <div class="col-md-6 col-md-offset-3">
        <form action="Actualizar.do" method="POST">
            <div class="form-group">
                <label for="perfilMail">Email</label>
                <input type="email" required class="form-control" name="perfilMail" id="perfilMail" value="${requestScope.email}">
            </div>
            <div class="form-group">
                <label for="perfilPassword">Password</label>
                <input type="password" required class="form-control" name="perfilPassword" id="loginPass" placeholder="Password">
            </div>
            <div class="form-group">
                <label for="confirmPassword">Repita password</label>
                <input type="password" required class="form-control" name="confirmPassword" id="confirmPassword" placeholder="Confirme password">
            </div>
            <button type="submit" class="btn btn-default">Actualizar</button>
        </form>
        <a href="master.jsp?page=index">Cancelar</a>
    </div>
</div>