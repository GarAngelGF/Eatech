function showLabel(text) {
    var labelContainer = document.getElementById('labelContainer');
    labelContainer.innerHTML = text;
}

function hideLabel() {
    var labelContainer = document.getElementById('labelContainer');
    labelContainer.innerHTML = '';
}

function changeContent(tab) {
    var content = document.getElementById('content');
    var container = document.createElement('div');
    container.classList.add('container');

    var title = document.createElement('h2');
    title.classList.add('title');
    var paragraph = document.createElement('p');
    paragraph.classList.add('paragraph');

    switch (tab) {
        case 'FUNCIONALIDADES':
            title.textContent = 'Funcionalidades';
            paragraph.textContent = 'Menús Nutricionales: La aplicación muestra los menús mensuales con información nutricional detallada y recomendaciones para las comidas.Comunicación Directa: Facilita la comunicación entre los usuarios y la coordinación del comedor, por ejemplo, para resolver dudas o reportar problemas.Se podrán realizar reservaciones y personalizar comidas con antelación.Tendrá un registro detallado de las alergias, padecimientos y preferencias alimenticias para garantizar una atención segura y personalizada.';
            break;
        case 'BENEFICIOS':
            title.textContent = 'Beneficios';
            paragraph.textContent = 'Eatech se puede utilizar para ayudar a obtener, almacenar y distribuir alimentos de manera eficiente. Aparte, no solo ahorra dinero en la gestión del comedor, sino que también facilita la obtención de comida. Con el análisis de datos, podemos reducir el desperdicio alimenticio que existen en los comedores. Ajustar la cantidad de alimentos producidos y almacenados en función de la demanda nos permite gastar menos dinero y así ahorrar más,mejorar la experiencia gastronómica de los estudiantes y adaptarla a sus necesidades será un beneficio para todos.';
            break;
        case 'PERSONALIZACIÓN':
            title.textContent = 'Personalización';
            paragraph.textContent = 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed condimentum, libero vitae fermentum convallis, lorem sapien aliquam lectus, sed dignissim justo tortor vel nulla. Integer vel fermentum odio. Phasellus tempor eros vel felis lobortis, non aliquam nunc fermentum. Pellentesque quis convallis magna. Integer in condimentum lorem. In hac habitasse platea dictumst. Vivamus in ante vitae sem lacinia rhoncus. Nullam in dignissim justo. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum nec velit a leo ullamcorper volutpat. Suspendisse potenti. Fusce accumsan nibh ut neque suscipit, a suscipit purus posuere. Phasellus semper lectus a ex tempor fermentum. Sed eu est volutpat, faucibus nisi id, hendrerit libero. Duis pretium augue et urna vehicula convallis. Nam ultrices felis a justo congue luctus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed condimentum, libero vitae fermentum convallis, lorem sapien aliquam lectus, sed dignissim justo tortor vel nulla. Integer vel fermentum odio. Phasellus tempor eros vel felis lobortis, non aliquam nunc fermentum. Pellentesque quis convallis magna. Integer in condimentum lorem. In hac habitasse platea dictumst. Vivamus in ante vitae sem lacinia rhoncus. Nullam in dignissim justo. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum nec velit a leo ullamcorper volutpat. Suspendisse potenti. Fusce accumsan nibh ut neque suscipit, a suscipit purus posuere. Phasellus semper lectus a ex tempor fermentum. Sed eu est volutpat, faucibus nisi id, hendrerit libero. Duis pretium augue et urna vehicula convallis. Nam ultrices felis a justo congue luctus. ';
            break;
        case 'SEGURIDAD DE EATECH':
            title.textContent = 'Seguridad';
            paragraph.textContent = 'Autenticación y Autorización: Implementa un sistema de autenticación sólido para garantizar que solo los usuarios autorizados puedan acceder a la aplicación. Además, establece roles y permisos para controlar el acceso a diferentes funciones.Encriptación de Datos: Asegura que la comunicación entre el cliente y el servidor está cifrada.También encripta los datos almacenados en la base de datos.';
            break;
        case 'MANUAL DE USO':
            title.textContent = 'Manual de uso';
            paragraph.textContent = 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed condimentum, libero vitae fermentum convallis, lorem sapien aliquam lectus, sed dignissim justo tortor vel nulla. Integer vel fermentum odio. Phasellus tempor eros vel felis lobortis, non aliquam nunc fermentum. Pellentesque quis convallis magna. Integer in condimentum lorem. In hac habitasse platea dictumst. Vivamus in ante vitae sem lacinia rhoncus. Nullam in dignissim justo. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum nec velit a leo ullamcorper volutpat. Suspendisse potenti. Fusce accumsan nibh ut neque suscipit, a suscipit purus posuere. Phasellus semper lectus a ex tempor fermentum. Sed eu est volutpat, faucibus nisi id, hendrerit libero. Duis pretium augue et urna vehicula convallis. Nam ultrices felis a justo congue luctus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed condimentum, libero vitae fermentum convallis, lorem sapien aliquam lectus, sed dignissim justo tortor vel nulla. Integer vel fermentum odio. Phasellus tempor eros vel felis lobortis, non aliquam nunc fermentum. Pellentesque quis convallis magna. Integer in condimentum lorem. In hac habitasse platea dictumst. Vivamus in ante vitae sem lacinia rhoncus. Nullam in dignissim justo. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum nec velit a leo ullamcorper volutpat. Suspendisse potenti. Fusce accumsan nibh ut neque suscipit, a suscipit purus posuere. Phasellus semper lectus a ex tempor fermentum. Sed eu est volutpat, faucibus nisi id, hendrerit libero. Duis pretium augue et urna vehicula convallis. Nam ultrices felis a justo congue luctus. ';
            break;
    }

    container.appendChild(title);
    container.appendChild(paragraph);
    content.innerHTML = '';
    content.appendChild(container);
}

