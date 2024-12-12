/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        './**/*.razor',     // Archivos Razor de Blazor
        './**/*.cshtml',    // Si usas archivos cshtml
        './wwwroot/**/*.html' // Archivos HTML estáticos
    ],
    theme: {
        extend: {},
    },
    plugins: [],
};
