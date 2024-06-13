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
            paragraph.textContent = 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed condimentum, libero vitae fermentum convallis, lorem sapien aliquam lectus, sed dignissim justo tortor vel nulla. Integer vel fermentum odio. Phasellus tempor eros vel felis lobortis, non aliquam nunc fermentum. Pellentesque quis convallis magna. Integer in condimentum lorem. In hac habitasse platea dictumst. Vivamus in ante vitae sem lacinia rhoncus. Nullam in dignissim justo. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum nec velit a leo ullamcorper volutpat. Suspendisse potenti. Fusce accumsan nibh ut neque suscipit, a suscipit purus posuere. Phasellus semper lectus a ex tempor fermentum. Sed eu est volutpat, faucibus nisi id, hendrerit libero. Duis pretium augue et urna vehicula convallis. Nam ultrices felis a justo congue luctus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed condimentum, libero vitae fermentum convallis, lorem sapien aliquam lectus, sed dignissim justo tortor vel nulla. Integer vel fermentum odio. Phasellus tempor eros vel felis lobortis, non aliquam nunc fermentum. Pellentesque quis convallis magna. Integer in condimentum lorem. In hac habitasse platea dictumst. Vivamus in ante vitae sem lacinia rhoncus. Nullam in dignissim justo. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum nec velit a leo ullamcorper volutpat. Suspendisse potenti. Fusce accumsan nibh ut neque suscipit, a suscipit purus posuere. Phasellus semper lectus a ex tempor fermentum. Sed eu est volutpat, faucibus nisi id, hendrerit libero. Duis pretium augue et urna vehicula convallis. Nam ultrices felis a justo congue luctus. ';
            break;
        case 'BENEFICIOS':
            title.textContent = 'Beneficios';
            paragraph.textContent = 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed condimentum, libero vitae fermentum convallis, lorem sapien aliquam lectus, sed dignissim justo tortor vel nulla. Integer vel fermentum odio. Phasellus tempor eros vel felis lobortis, non aliquam nunc fermentum. Pellentesque quis convallis magna. Integer in condimentum lorem. In hac habitasse platea dictumst. Vivamus in ante vitae sem lacinia rhoncus. Nullam in dignissim justo. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum nec velit a leo ullamcorper volutpat. Suspendisse potenti. Fusce accumsan nibh ut neque suscipit, a suscipit purus posuere. Phasellus semper lectus a ex tempor fermentum. Sed eu est volutpat, faucibus nisi id, hendrerit libero. Duis pretium augue et urna vehicula convallis. Nam ultrices felis a justo congue luctus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed condimentum, libero vitae fermentum convallis, lorem sapien aliquam lectus, sed dignissim justo tortor vel nulla. Integer vel fermentum odio. Phasellus tempor eros vel felis lobortis, non aliquam nunc fermentum. Pellentesque quis convallis magna. Integer in condimentum lorem. In hac habitasse platea dictumst. Vivamus in ante vitae sem lacinia rhoncus. Nullam in dignissim justo. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum nec velit a leo ullamcorper volutpat. Suspendisse potenti. Fusce accumsan nibh ut neque suscipit, a suscipit purus posuere. Phasellus semper lectus a ex tempor fermentum. Sed eu est volutpat, faucibus nisi id, hendrerit libero. Duis pretium augue et urna vehicula convallis. Nam ultrices felis a justo congue luctus. ';
            break;
        case 'PERSONALIZACIÓN':
            title.textContent = 'Personalización';
            paragraph.textContent = 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed condimentum, libero vitae fermentum convallis, lorem sapien aliquam lectus, sed dignissim justo tortor vel nulla. Integer vel fermentum odio. Phasellus tempor eros vel felis lobortis, non aliquam nunc fermentum. Pellentesque quis convallis magna. Integer in condimentum lorem. In hac habitasse platea dictumst. Vivamus in ante vitae sem lacinia rhoncus. Nullam in dignissim justo. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum nec velit a leo ullamcorper volutpat. Suspendisse potenti. Fusce accumsan nibh ut neque suscipit, a suscipit purus posuere. Phasellus semper lectus a ex tempor fermentum. Sed eu est volutpat, faucibus nisi id, hendrerit libero. Duis pretium augue et urna vehicula convallis. Nam ultrices felis a justo congue luctus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed condimentum, libero vitae fermentum convallis, lorem sapien aliquam lectus, sed dignissim justo tortor vel nulla. Integer vel fermentum odio. Phasellus tempor eros vel felis lobortis, non aliquam nunc fermentum. Pellentesque quis convallis magna. Integer in condimentum lorem. In hac habitasse platea dictumst. Vivamus in ante vitae sem lacinia rhoncus. Nullam in dignissim justo. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum nec velit a leo ullamcorper volutpat. Suspendisse potenti. Fusce accumsan nibh ut neque suscipit, a suscipit purus posuere. Phasellus semper lectus a ex tempor fermentum. Sed eu est volutpat, faucibus nisi id, hendrerit libero. Duis pretium augue et urna vehicula convallis. Nam ultrices felis a justo congue luctus. ';
            break;
        case 'SEGURIDAD DE EATECH':
            title.textContent = 'Seguridad';
            paragraph.textContent = 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed condimentum, libero vitae fermentum convallis, lorem sapien aliquam lectus, sed dignissim justo tortor vel nulla. Integer vel fermentum odio. Phasellus tempor eros vel felis lobortis, non aliquam nunc fermentum. Pellentesque quis convallis magna. Integer in condimentum lorem. In hac habitasse platea dictumst. Vivamus in ante vitae sem lacinia rhoncus. Nullam in dignissim justo. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum nec velit a leo ullamcorper volutpat. Suspendisse potenti. Fusce accumsan nibh ut neque suscipit, a suscipit purus posuere. Phasellus semper lectus a ex tempor fermentum. Sed eu est volutpat, faucibus nisi id, hendrerit libero. Duis pretium augue et urna vehicula convallis. Nam ultrices felis a justo congue luctus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed condimentum, libero vitae fermentum convallis, lorem sapien aliquam lectus, sed dignissim justo tortor vel nulla. Integer vel fermentum odio. Phasellus tempor eros vel felis lobortis, non aliquam nunc fermentum. Pellentesque quis convallis magna. Integer in condimentum lorem. In hac habitasse platea dictumst. Vivamus in ante vitae sem lacinia rhoncus. Nullam in dignissim justo. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum nec velit a leo ullamcorper volutpat. Suspendisse potenti. Fusce accumsan nibh ut neque suscipit, a suscipit purus posuere. Phasellus semper lectus a ex tempor fermentum. Sed eu est volutpat, faucibus nisi id, hendrerit libero. Duis pretium augue et urna vehicula convallis. Nam ultrices felis a justo congue luctus. ';
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
