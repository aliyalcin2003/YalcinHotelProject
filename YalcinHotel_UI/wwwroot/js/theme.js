// Tema kodu site ve admin panelinde ortaktır; iki ekrandaki düğmeler aynı tercihi değiştirir.
document.addEventListener("DOMContentLoaded", () => {
    const themeButtons = document.querySelectorAll("[data-theme-toggle]");

    // Tema değişince düğmenin erişilebilir açıklaması, etiketi ve simgesi birlikte güncellenir.
    const updateThemeButtons = (theme) => {
        themeButtons.forEach((button) => {
            const isDark = theme === "dark";
            button.setAttribute("aria-label", isDark ? "Açık temaya geç" : "Karanlık temaya geç");
            button.setAttribute("aria-checked", String(isDark));
            button.querySelector("[data-switch-label]").textContent = isDark ? "GECE" : "GÜNDÜZ";
            button.querySelector("[data-switch-icon]").className = isDark ? "fa-solid fa-moon" : "fa-solid fa-sun";
        });
    };

    // Önceki seçim varsa onu kullanır; ilk ziyarette açık tema varsayılandır.
    let theme = document.documentElement.dataset.theme || "light";
    updateThemeButtons(theme);

    // Anahtara basıldığında görünümü değiştirip tercihi sonraki sayfalar için saklar.
    themeButtons.forEach((button) => {
        button.addEventListener("click", () => {
            theme = theme === "dark" ? "light" : "dark";
            document.documentElement.dataset.theme = theme;
            localStorage.setItem("yalcin-hotel-theme", theme);
            updateThemeButtons(theme);
        });
    });
});
