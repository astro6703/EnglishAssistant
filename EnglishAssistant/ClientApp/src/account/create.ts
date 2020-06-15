import * as ko from 'knockout';
import 'knockout.validation';

import './create.scss';

class CreateViewModel {
    public readonly username: KnockoutObservable<string>;
    public readonly password: KnockoutObservable<string>;
    public readonly confirmPassword: KnockoutObservable<string>;
    public readonly isFormValid: KnockoutComputed<boolean>;

    constructor() {
        this.username = ko.observable('').extend({ required: true });
        this.password = ko.observable('').extend({ required: true });
        this.confirmPassword = ko.observable('').extend({ equal: this.password });
        this.isFormValid = ko.pureComputed(() => this.username.isValid()
                                                 && this.password.isValid()
                                                 && this.confirmPassword.isValid());
    }
}

ko.applyBindings(new CreateViewModel());