<div class="row">
    <div class="col-md-6 col-md-offset-3">
        <form action="/Registro.do">
            <div class="form-group">
                <label for="loginmail">Email</label>
                <input type="email" class="form-control" id="registromail" placeholder="Email">
            </div>
            <div class="form-group">
                <label for="loginpass">Password</label>
                <input type="password" class="form-control" id="registropass" placeholder="Password">
            </div>
            <div class="form-group">
                <label for="loginpass">RUT</label>
                <span>
                    <input type="number" class="form-control" id="registrorut" placeholder="Password">-
                    <input type="password" class="form-control" maxlength="1" size="1" id="registroDV">
                </span>
            </div>
            <div class="form-group">
                <label for="registronombre">Nombres</label>
                <input type="text" class="form-control" id="registronombre" placeholder="Nombres">
            </div>
            <div class="form-group">
                <label for="registroApellidos">Apellidos</label>
                <input type="text" class="form-control" id="registroApellidos" placeholder="Apellidos">
            </div>
            <div class="form-group">
                <label for="registrofecnac">Fecha de nacimiento</label>
                <input type="date" class="form-control" id="registrofecnac">
            </div>
            <div class="form-group">
                <label for="registrofecnac">Fecha de nacimiento</label>
                <input type="date" class="form-control" id="registrofecnac">
            </div>
            <div class="radio">
                <label>
                    <input type="radio" name="registroSexo" id="radioM" value="M" checked>
                    Masculino
                </label>
            </div>
            <div class="radio">
                <label>
                    <input type="radio" name="registroSexo" id="radioF" value="option2">
                    Femenino
                </label>
            </div>
            <button type="submit" class="btn btn-default">Registrarse</button>
        </form>
    </div>
</div>