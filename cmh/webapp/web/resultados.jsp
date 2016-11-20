<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<jsp:include page="/Resultados.do" flush="true"/>
<div class="row">
    <div class="col-md-6 col-md-offset-3">
        
            <c:forEach items="${requestScope.resultados}" var="resultado">
                <div>
                    <a href="data:application/pdf;base64,${resultado.getArchivoB64()}" download>${resultado.getIdAtencionAgen().getIdPrestacion().getNomPrestacion()}
                    ${resultado.getIdAtencionAgen().getFechor()}</a>
                </div>
            </c:forEach>
    </div>
</div>