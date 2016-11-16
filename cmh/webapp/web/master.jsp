<%-- 
    Document   : index
    Created on : 11-nov-2016, 12:58:01
    Author     : dev
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<jsp:include page="/Router.do" flush="true" />
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<!DOCTYPE html>
<html>
    <jsp:include page="/segments/head.jsp"/>

    <body>

        <jsp:include page="/segments/nav.jsp"/>
        <jsp:include page="/segments/header.jsp"/>
        

        <!-- Page Content -->
        <div class="container">
            
            <jsp:include page="${requestScope.page}" flush="true"/>
            
            <jsp:include page="/segments/footer.jsp" flush="true"/>
        </div>
        <!-- /.container -->
    </body>
</html>
