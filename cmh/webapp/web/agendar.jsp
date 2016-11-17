<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<jsp:include page="/Agendamiento.do" flush="true" />
<div class="row">
    <div class="col-md-8 col-md-offset-2">
        <form action="master.jsp?page=agendar" method="POST">
            <div class="form-group">
                <label for="tipoPres">Tipo prestación</label>
                <select class="form-control" id="ddlTipoPres" name="tipoPres" onchange="this.form.submit()">
                    <c:forEach var="tipoPrestacion" items="${requestScope.tiposPres}">
                        <option value="${tipoPrestacion.getIdTipoPrestacion()}">${tipoPrestacion.getNomTipoPrest()}</option>
                    </c:forEach>
                </select>
            </div>
            <div class="form-group">
                <label for="prestacion">Prestacion</label>
                <select class="form-control" name="prestacion">
                    <c:forEach var="prestacion" items="${requestScope.prestaciones}">
                        <option value="${prestacion.getIdPrestacion()}">${prestacion.getNomPrestacion()}</option>
                    </c:forEach>
                </select>
            </div>
            <div class="form-group">
                <label for="medico">Medico</label>
                <select class="form-control" name="prestacion">
                    
                </select>
            </div>
            <div class="form-group">
                <label for="medico">Medico</label>
                <select class="form-control" name="prestacion">
                    
                </select>
            </div>
            <div class="form-group">
                <label for="fecha">Fecha</label>
                <input type="date" name="fecha"/>
            </div>
            <div class="form-group">
                <label for="bloque">Hora</label>
                <select class="form-control" name="bloque">
                    
                </select>
            </div>
            
            <button type="submit" class="btn btn-default">Reservar</button>
        </form>  
    </div>
</div>