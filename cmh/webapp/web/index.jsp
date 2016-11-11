<%-- 
    Document   : index
    Created on : 11-nov-2016, 12:58:01
    Author     : dev
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>

<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<!DOCTYPE html>
<html>
    <jsp:include page="/segments/head.jsp"/>

    <body>

        <jsp:include page="/segments/nav.jsp"/>

        <!-- Header Carousel -->
        <header id="myCarousel" class="carousel slide">
            <!-- Indicators -->
            <ol class="carousel-indicators">
                <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                <li data-target="#myCarousel" data-slide-to="1"></li>
                <li data-target="#myCarousel" data-slide-to="2"></li>
            </ol>

            <!-- Wrapper for slides -->
            <div class="carousel-inner">
                <div class="item active">
                    <div class="fill" style="background-image:url('img/slider1.jpg');"></div>
                    <div class="carousel-caption">
                        <h2>Personal capacitado</h2>
                    </div>
                </div>
                <div class="item">
                    <div class="fill" style="background-image:url('img/slider2.jpg');"></div>
                    <div class="carousel-caption">
                        <h2>Profesionales de calidad</h2>
                    </div>
                </div>
                <div class="item">
                    <div class="fill" style="background-image:url('img/slider3.jpg');"></div>
                    <div class="carousel-caption">
                        <h2>Equipamiento de última generación</h2>
                    </div>
                </div>
            </div>

            <!-- Controls -->
            <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                <span class="icon-prev"></span>
            </a>
            <a class="right carousel-control" href="#myCarousel" data-slide="next">
                <span class="icon-next"></span>
            </a>
        </header>

        <!-- Page Content -->
        <div class="container">

            <!-- Marketing Icons Section -->
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">
                        Bienvenido al Centro Médico Hipócrates
                    </h1>
                </div>
                <div class="col-md-4">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4><i class="fa fa-fw fa-calendar"></i>Reserva de horas</h4>
                        </div>
                        <div class="panel-body">
                            <p>Agende su atención con cualquiera de nuestros especialistas</p>
                            <a href="#" class="btn btn-default">Ir a reservar una hora</a>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4><i class="fa fa-fw fa-heartbeat"></i>Resultados de exámenes</h4>
                        </div>
                        <div class="panel-body">
                            <p>Vea y descargue los resultados de sus exámenes aquí.</p>
                            <a href="#" class="btn btn-default">Ir a resultados de exámenes</a>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4><i class="fa fa-fw fa-calendar-times-o"></i>Anular hora</h4>
                        </div>
                        <div class="panel-body">
                            <p>¿Se equivocó de hora o no va a poder asistir a su hora agendada? No hay problema, anúlela y vuelva a agendar una nueva.</p>
                            <a href="#" class="btn btn-default">Ir a anular horas</a>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.row -->


            <!-- Features Section -->
            <div class="row">
                <div class="col-lg-12">
                    <h2 class="page-header">Ubicación</h2>
                </div>
                <div class="col-md-6">
                    <p>Nuestra institución está ubicada en el centro de Providencia</p>
                    <ul>
                        <li>Teléfono (562) 23478794</li>
                        <li>Av. Pedro de Valdivia #786</li>
                        <li>A pasos del metro Pedro de Valdivia</li>
                        <li>Atenciones de lunes a viernes</li>
                        <li>Horario de atención: 08:00 - 19:00</li>
                    </ul>
                </div>
                <div class="col-md-6">
                    <iframe width="100%" height="400px" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3329.728896329939!2d-70.61188588518378!3d-33.4303116807798!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x9662cf707635d857%3A0x15eda11112c58f00!2sAv.+Pedro+de+Valdivia+786%2C+Providencia%2C+Regi%C3%B3n+Metropolitana!5e0!3m2!1ses!2scl!4v1478808732974"></iframe>
                </div>
            </div>
            <!-- /.row -->

            <hr>

            <!-- Call to Action Section -->
            <div class="well">
                <div class="row">
                    <div class="col-md-8">
                        <p>¿Quieres acceder a alguno de nuestros servicios online? Inicia sesión</p>
                    </div>
                    <div class="col-md-4">
                        <a class="btn btn-lg btn-default btn-block" href="#">Iniciar sesión</a>
                    </div>
                </div>
            </div>
            <jsp:include page="/segments/footer.jsp" flush="true"/>
        </div>
        <!-- /.container -->
    </body>
</html>
