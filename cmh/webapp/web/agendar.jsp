<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<jsp:include page="/Agendamiento.do" />
<div class="row">
    <div class="col-md-8 col-md-offset-2">
        <form action="master.jsp?page=agendar" method="POST">
            <div class="form-group">
                
                <label for="tipoPrestacion">Tipo prestación</label>
                <select class="form-control" id="tipoPrestacion" name="tipoPrestacion" onchange="this.form.submit()">
                    <c:if test="${empty requestScope.tipoPrestacion}">
                        <option value='-1'>---</option>
                    </c:if>
                    <c:forEach var="tipoPrestacion" items="${requestScope.tiposPrestacion}">
                        <option value="${tipoPrestacion.getIdTipoPrestacion()}" ${tipoPrestacion.getIdTipoPrestacion() == requestScope.tipoPrestacion.getIdTipoPrestacion()? 'selected' : ''}>
                            ${tipoPrestacion.getNomTipoPrest()}
                        </option>
                    </c:forEach>
                </select>
            </div>

            <button type="submit" class="btn btn-default">Reservar</button>
        </form>  
    </div>
</div>