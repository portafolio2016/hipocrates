<jsp:include page="/Resultado.do"/>

<div class="row">
    <div class="col-md-8 col-md-offset-2">
        
        <div class='embed-responsive' style='padding-bottom:150%'>
            <embed src="data:application/pdf;base64,${requestScope.archivo}" width='100%' height='100%' >            
        </div>
    </div>

</div>

