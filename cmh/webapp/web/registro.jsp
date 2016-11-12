<div class="row">
    <div class="col-lg-6 col-lg-offset-3">
        <form action="Registro.do" method="POST">
            <div class="form-group">
                <label for="loginmail">Email</label>
                <input type="email" name="registromail" class="form-control" id="registromail" placeholder="Email" required>
            </div>
            <div class="form-group">
                <label for="loginpass">Password</label>
                <input type="password" name="registropass" class="form-control" id="registropass" placeholder="Password" required>
            </div>
            <div class="form-group">
                <label for="loginpass">RUT</label>
                <span>
                    <input type="number" name="registrorut" class="form-control" id="registrorut" placeholder="Password" required>-
                    <input type="text" name="registroDV" class="form-control" maxlength="1" size="1" id="registroDV" required>
                </span>
            </div>
            <div class="form-group">
                <label for="registroNombres">Nombres</label>
                <input type="text" name="registroNombres" class="form-control" id="registroNombres" placeholder="Nombres" required>
            </div>
            <div class="form-group">
                <label for="registroApellidos">Apellidos</label>
                <input type="text" name="registroApellidos" class="form-control" id="registroApellidos" placeholder="Apellidos" required>
            </div>
            <div class="form-group">
                <label for="registrofecnac">Fecha de nacimiento</label>
                <input type="date" name="registrofecnac" class="form-control" id="registrofecnac" required>
            </div>
            <div class="radio">
                <label>
                    <input type="radio" name="registroSexo" id="radioM" value="M" checked >
                    Masculino
                </label>
            </div>
            <div class="radio">
                <label>
                    <input type="radio" name="registroSexo" id="radioF" value="F">
                    Femenino
                </label>
            </div>
            <button type="submit" class="btn btn-default">Registrarse</button>
        </form>
    </div>
</div>