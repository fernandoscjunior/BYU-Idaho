const firstText = "Tererê or Mate is a cold drink made with crushed mate leaves called erva-mate (Ilex paraguariensis) and cool water or juice (sometimes there are other leaves to inhence the flavour) . It is very popular in some regions of South America being widely consumed in Paraguay, Brazil, Argentina, and Bolivia, it is more than just a drink though, it is a form of culture and expressing yourself, it helps you make new friends and be part of a community. On this Website you will see about Tererê's history, it's healthy properties and how to prepare your own Tererê at home, interested? Just click around and see it for yourself.";

const secondText = "The name tererê originates from the Guarani language, spoken by indigenous communities in South America. It is believed that the term mimics the sound of water being poured over the erva-mate and filtered through the bomba (metal straw) when drinking. In Paraguay and Argentina, the spelling tereré is commonly used, reflecting the pronunciation in Spanish and Guarani. In Brazil, particularly in Mato Grosso do Sul, both tererê and tereré are used interchangeably, with the former being influenced by Portuguese phonetics.";

//Function to change beetwen paragraphs on home page
function toggleText() {
    var text = document.getElementById("dynamicText");
    var button = document.getElementById("button");

    text.style.opacity = "0";

    setTimeout(() => {
        if (text.innerHTML === secondText) {
            text.innerHTML = firstText;
            button.innerHTML = "Show more";
        } else {
            text.innerHTML = secondText;
            button.innerHTML = "Go back";
        }
        text.style.opacity = "1"; 
        }, 500);
}               