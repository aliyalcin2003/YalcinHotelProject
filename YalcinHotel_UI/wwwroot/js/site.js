document.addEventListener("DOMContentLoaded", () => {
    const navToggle = document.querySelector("[data-nav-toggle]");
    const navMenu = document.querySelector("[data-nav-menu]");
    navToggle?.addEventListener("click", () => {
        const expanded = navToggle.getAttribute("aria-expanded") === "true";
        navToggle.setAttribute("aria-expanded", String(!expanded));
        navMenu?.classList.toggle("is-open", !expanded);
    });

    const accountToggle = document.querySelector("[data-account-toggle]");
    const accountMenu = document.querySelector("[data-account-menu]");
    accountToggle?.addEventListener("click", () => {
        const expanded = accountToggle.getAttribute("aria-expanded") === "true";
        accountToggle.setAttribute("aria-expanded", String(!expanded));
        accountMenu?.classList.toggle("is-open", !expanded);
    });
    document.addEventListener("click", (event) => {
        if (accountMenu && !accountMenu.contains(event.target)) {
            accountMenu.classList.remove("is-open");
            accountToggle?.setAttribute("aria-expanded", "false");
        }
    });

    const profileUrl = document.querySelector("[data-profile-url]");
    const profilePreview = document.getElementById("profilePreview");
    profileUrl?.addEventListener("input", () => {
        if (profilePreview && profileUrl.value) {
            profilePreview.src = profileUrl.value;
        }
    });

    const checkIn = document.getElementById("CheckIn");
    const checkOut = document.getElementById("CheckOut");
    checkIn?.addEventListener("change", () => {
        if (!checkOut) {
            return;
        }
        checkOut.min = checkIn.value
            ? new Date(new Date(checkIn.value).getTime() + 86400000).toISOString().slice(0, 10)
            : "";
        if (checkOut.value && checkOut.value <= checkIn.value) {
            checkOut.value = "";
        }
    });

    document.querySelectorAll("[data-room-carousel]").forEach((carousel) => {
        const track = carousel.querySelector("[data-room-track]");
        const section = carousel.closest(".rooms-section");
        const step = () => {
            const card = track?.querySelector(".room-card");
            if (!card || !track) {
                return 0;
            }
            const gap = Number.parseFloat(getComputedStyle(track).columnGap) || 0;
            return card.getBoundingClientRect().width + gap;
        };
        section?.querySelector("[data-room-prev]")?.addEventListener("click", () => {
            track?.scrollBy({ left: -step(), behavior: "smooth" });
        });
        section?.querySelector("[data-room-next]")?.addEventListener("click", () => {
            track?.scrollBy({ left: step(), behavior: "smooth" });
        });
    });
});
