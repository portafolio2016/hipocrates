<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<jsp:include page="/Anular.do" flush="true"/>
<div class="row">
    <div class="col-md-6 col-md-offset-3">
        <form action="" method="POST">
            <input type="hidden" name="atencionAnulada" id="atencionAnulada" />
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
                                ${atencion.getIdBloque().getNumHoraIni()}:${atencion.getIdBloque().getNumMinuIni()}<c:if test="${atencion.getIdBloque().getNumMinuIni() == 0}">0</c:if>
                            </td>
                            <td>
                                <input type="submit" value="Anular" onclick="$('#atencionAnulada').val(${atencion.getIdAtencionAgen()});" class="btn btn-default"/>
                            </td>
                        </tr>
                    </c:forEach>
                </table>
            </div>
        </form>
    </div>
</div>