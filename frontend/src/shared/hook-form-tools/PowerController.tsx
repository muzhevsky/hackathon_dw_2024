import * as React from "react";
import {
    Controller,
    ControllerFieldState,
    ControllerProps,
    ControllerRenderProps,
    FieldError,
    FieldPath,
    FieldValues,
    Path,
    UseFormStateReturn
} from "react-hook-form";
import { usePowerController } from "./usePowerController";


export interface WarningRule<ValidatorTarget> {
    validator: (value: ValidatorTarget) => boolean,
    message: string
}

export type Formater<VType> = (v: VType | null) => VType;

export type Status = "" | "error" | "warning" | undefined;
export type WarningValueType<TFeildValues extends FieldValues, TName extends Path<TFeildValues>> = ControllerRenderProps<TFeildValues, TName>['value']
export type FormaterValueType<TFeildValues extends FieldValues, TName extends Path<TFeildValues>> = ControllerRenderProps<TFeildValues, TName>['value']

type PowerControllerProps<TFeildValues extends FieldValues, TName extends Path<TFeildValues>> = Omit<ControllerProps<TFeildValues, TName>, "render"> & {
    render: ({ field, fieldState, formState, }: {
        field: ControllerRenderProps<TFeildValues, TName> & { status: Status, };
        fieldState: ControllerFieldState & { warning?: string };
        formState: UseFormStateReturn<TFeildValues>;
    }) => React.ReactElement,
    warn?: WarningRule<WarningValueType<TFeildValues, TName>>[],
    onWarn?: (warning: string) => void,
    onError?: (error: string) => void,
    formater?: Formater<FormaterValueType<TFeildValues, TName>>

};

const PowerController = <TFieldValues extends FieldValues = FieldValues, TName extends FieldPath<TFieldValues> = FieldPath<TFieldValues>>(props: PowerControllerProps<TFieldValues, TName>) => {

    const { field, fieldState, formState } = usePowerController(props);

    React.useEffect(
        () => {
            const onWarnCallback = props.onWarn;
            if (onWarnCallback && fieldState.warning) onWarnCallback(fieldState.warning);
        },
        [fieldState.warning]
    )

    React.useEffect(
        () => {
            const onErrorCallback = props.onError;
            if (onErrorCallback && fieldState.error?.message) onErrorCallback(fieldState.error.message);
        },
        [fieldState.error]
    )

    const formattedValue = React.useMemo(
        () => props.formater
            ? props.formater(field.value)
            : field.value,
        [props.formater, field.value]
    );

    return props.render({
        field: {...field, value: formattedValue},
        fieldState,
        formState
    })
};

export default PowerController;