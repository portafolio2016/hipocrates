<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<jsp:include page="/Resultados.do" flush="true"/>
<div class="row">
    <div class="col-md-6 col-md-offset-3">
        <form>
            <c:forEach items="${requestScope.resultados}" var="resultado">
                <div>
                    <a href="master.jsp?page=resultado&resultado=${resultado.getIdResultadoAtencion()}">${resultado.getIdAtencionAgen().getIdPrestacion().getNomPrestacion()}
                    ${resultado.getIdAtencionAgen().getFechor()}</a>
                </div>
            </c:forEach>
        </form>
    </div>
</div>