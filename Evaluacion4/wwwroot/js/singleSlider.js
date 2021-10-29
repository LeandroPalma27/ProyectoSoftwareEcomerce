window.addEventListener('load', function (e) {
    new Glider(document.querySelector('.carousel__lista'), {
        slidesToShow: 1,
        dots: '.carousel__indicadores',
        draggable: false,
        arrows: {
            prev: '.carousel__anterior',
            next: '.carousel__siguiente'
        }
    });
});
