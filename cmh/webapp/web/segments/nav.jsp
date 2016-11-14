<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<%-- 
    Document   : nav
    Created on : 11-nov-2016, 13:24:22
    Author     : dev
--%>
<!-- Navigation -->
<jsp:include page="../Nav.do" flush="true" />
<nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
    <div class="container">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="master.jsp?page=index">
                <span><img src="img/icon1.png" height="30px" width="30px"/><span>
                        Centro Médico Hipócrates
                        </a>
                        </div>
                        <!-- Collect the nav links, forms, and other content for toggling -->
                        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                            <ul class="nav navbar-nav navbar-right">
                                <li>
                                    <a href="master.jsp?page=index">Home</a>
                                </li>
                                <li>
                                    <a href="master.jsp?page=quienes-somos">Quiénes Somos</a>
                                </li>
                                <li>
                                    <a href="master.jsp?page=servicios">Servicios</a>
                                </li>
                                <c:if test="${requestScope.mostrarLogin}">
                                    <li>
                                        <a href="master.jsp?page=login">Iniciar sesión</a>
                                    </li>    
                                </c:if>
                                <c:if test="${!requestScope.mostrarLogin}">
                                    <li>
                                        <a href="Logout.do">Cerrar sesión</a>
                                    </li>    
                                </c:if>
                            </ul>
                        </div>
                        <!-- /.navbar-collapse -->
                        </div>
                        <!-- /.container -->
                        </nav>
