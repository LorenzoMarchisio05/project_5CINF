select P1.idOfferente, (ISNULL((select sum(NOre) from Prestazioni as P2 where P2.IdOfferente = P1.IdOfferente), 0) 
- (ISNULL((select sum(NOre) from Prestazioni as P3 where P3.IdRicevente = P1.IdOfferente), 0))) as 'differenza prestazione'
from Prestazioni as P1
group by P1.IdOfferente;


