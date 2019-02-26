import { AliasIHttpProvider } from './../interfaces/IHttpProvider';
import { HttpProviderService } from './../services/HttpProviderService';
import { VacancyService } from './../services/VacancyService';
import { EventService } from './../services/EventService';
import { ApiPathProvider } from './apiPathProvider';


export const Providers = [
    { provide: AliasIHttpProvider,  useClass: HttpProviderService }, ApiPathProvider, VacancyService, EventService
];
