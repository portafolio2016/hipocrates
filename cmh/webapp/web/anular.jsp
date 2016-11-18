<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<jsp:include page="/Anular.do" flush="true"/>
<div class="row">
    <div class="col-md-6 col-md-offset-3">
        <form action="" method="POST">
            <input type="hidden" name="atencionAnulada" id="idAtencion" />
            <div class="table-responsive">
                <table class="table table-bordered">
                    <tr>
                        <th>Prestacion</th>
                        <th>Fecha</th> 
                        <th>Hora</th>
                        <th></th>
                    </tr>
                    <c:forEach items="${requestScope.atenciones}" var="atencion">
                        <tr>
                            <td>
                                ${atencion.getIdPrestacion().getNomPrestacion()}
                            </td>
                            <td>
                                ${atencion.getFechor()}
                            </td>
                            <td>
                                ${atencion.get}
                            </td>
                            <td>
                                <input type="submit" value="Anular" onclick="$('#hiddenRegistrar').val(${atencion.getIdAtencionAgen()});" class="btn btn-default"/>
                            </td>
                        </tr>
                    </c:forEach>
                </table>
            </div>

        </form>
        <a href="master.jsp?page=registro">Registrarse</a>
    </div>
</div>