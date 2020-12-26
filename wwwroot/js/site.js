
!(function($) {
    
  
    // AGREGANDO CLASE ACTIVE AL PRIMER ENLACE ====================
    $('.category_list .category_item[category="all"]').addClass('ct_item-active');
  
    // FILTRANDO PRODUCTOS  ============================================
  
    $('.category_item').click(function(){
      var catProduct = $(this).attr('category');
      console.log(catProduct);
  
      // AGREGANDO CLASE ACTIVE AL ENLACE SELECCIONADO
      $('.category_item').removeClass('ct_item-active');
      $(this).addClass('ct_item-active');
  
      // OCULTANDO PRODUCTOS =========================
      $('.product-item').css('transform', 'scale(0)');
      function hideProduct(){
        $('.product-item').hide();
      } setTimeout(hideProduct,400);
  
      // MOSTRANDO PRODUCTOS =========================
      function showProduct(){
        $('.product-item[category="'+catProduct+'"]').show();
        $('.product-item[category="'+catProduct+'"]').css('transform', 'scale(1)');
      } setTimeout(showProduct,400);
    });
  
    // MOSTRANDO TODOS LOS PRODUCTOS =======================
  
    $('.category_item[category="all"]').click(function(){
      function showAll(){
        $('.product-item').show();
        $('.product-item').css('transform', 'scale(1)');
      } setTimeout(showAll,400);
    });
    
    
  
  

    $(window).on('load', function() {
      var portfolioIsotope = $('.portfolio-container').isotope({
        itemSelector: '.portfolio-item',
        layoutMode: 'fitRows'
      });
  
      $('#portfolio-flters li').on('click', function() {
        $("#portfolio-flters li").removeClass('filter-active');
        $(this).addClass('filter-active');
  
        portfolioIsotope.isotope({
          filter: $(this).data('filter')
        });
        aos_init();
      });
  
      $(document).ready(function() {
        $('.venobox').venobox();
      });
    });
  

    function aos_init() {
      AOS.init({
        duration: 800,
        easing: "ease-in-out",
        once: true
      });
    }
    $(window).on('load', function() {
      aos_init();
    });
  
  })(jQuery);
